﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;

using XLabs.Platform.Services.Media;
using App1.Droid;
using Xamarin.Forms;

namespace App1.Droid
{
    /// <summary>
    ///     Class MediaPicker.
    /// </summary>
    public class MediaPicker : Controls.IMediaPicker
    {
        private TaskCompletionSource<MediaFile> _completionSource;
        private int _requestId;

        private static Context Context
        {
            get { return Context; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaPicker"/> class.
        /// </summary>
        public MediaPicker()
        {
            IsPhotosSupported = true;
            IsVideosSupported = true;
        }

        /// <summary>	
        /// Gets a value indicating whether this instance is camera available.
        /// </summary>
        /// <value><c>true</c> if this instance is camera available; otherwise, <c>false</c>.</value>
        public bool IsCameraAvailable
        {
            get
            {
                var isCameraAvailable = Context.PackageManager.HasSystemFeature(PackageManager.FeatureCamera);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Gingerbread)
                {
                    isCameraAvailable |= Context.PackageManager.HasSystemFeature(PackageManager.FeatureCameraFront);
                }

                return isCameraAvailable;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is photos supported.
        /// </summary>
        /// <value><c>true</c> if this instance is photos supported; otherwise, <c>false</c>.</value>
        public bool IsPhotosSupported { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is videos supported.
        /// </summary>
        /// <value><c>true</c> if this instance is videos supported; otherwise, <c>false</c>.</value>
        public bool IsVideosSupported { get; private set; }

        /// <summary>
        /// Select a picture from library.
        /// </summary>
        /// <param name="options">The storage options.</param>
        /// <returns>Task with a return type of MediaFile.</returns>
        /// <exception cref="System.NotSupportedException">Throws an exception if feature is not supported.</exception>
        public Task<MediaFile> SelectPhotoAsync(CameraMediaStorageOptions options)
        {
            if (!IsCameraAvailable)
            {
                throw new NotSupportedException();
            }

            options.VerifyOptions();
             
            return TakeMediaAsync("image/*", Intent.ActionPick, options);
        }

        /// <summary>
        /// Takes the picture.
        /// </summary>
        /// <param name="options">The storage options.</param>
        /// <returns>Task with a return type of MediaFile.</returns>
        /// <exception cref="System.NotSupportedException">Throws an exception if feature is not supported.</exception>
        public Task<MediaFile> TakePhotoAsync(CameraMediaStorageOptions options)
        {
            if (!IsCameraAvailable)
            {
                throw new NotSupportedException();
            }

            options.VerifyOptions();

            return TakeMediaAsync("image/*", MediaStore.ActionImageCapture, options);
        }

        /// <summary>
        /// Selects the video asynchronous.
        /// </summary>
        /// <param name="options">Video storage options.</param>
        /// <returns>Task with a return type of MediaFile.</returns>
        /// <exception cref="System.NotSupportedException">Throws an exception if feature is not supported.</exception>
        public Task<MediaFile> SelectVideoAsync(VideoMediaStorageOptions options)
        {
            if (!IsCameraAvailable)
            {
                throw new NotSupportedException();
            }

            options.VerifyOptions();

            return TakeMediaAsync("video/*", Intent.ActionPick, options);
        }

        /// <summary>
        /// Takes the video asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task with a return type of MediaFile.</returns>
        /// <exception cref="System.NotSupportedException">Throws an exception if feature is not supported.</exception>
        public Task<MediaFile> TakeVideoAsync(VideoMediaStorageOptions options)
        {
            if (!IsCameraAvailable)
            {
                throw new NotSupportedException();
            }

            options.VerifyOptions();

            return TakeMediaAsync("video/*", MediaStore.ActionVideoCapture, options);
        }

        /// <summary>
        /// Gets or sets the event that fires when media has been selected.
        /// </summary>
        /// <value>The on photo selected.</value>
        public EventHandler<MediaPickerArgs> OnMediaSelected { get; set; }

        /// <summary>
        ///     Gets or sets the on error.
        /// </summary>
        /// <value>The on error.</value>
        public EventHandler<MediaPickerErrorArgs> OnError { get; set; }
        EventHandler<Controls.MediaPickerArgs> Controls.IMediaPicker.OnMediaSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        EventHandler<Controls.MediaPickerErrorArgs> Controls.IMediaPicker.OnError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Creates the media intent.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type of intent.</param>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <param name="tasked">if set to <c>true</c> [tasked].</param>
        /// <returns>Intent to create media.</returns>
        private Intent CreateMediaIntent(int id, string type, string action, MediaStorageOptions options, bool tasked = true)
        {
            var pickerIntent = new Intent(Context, typeof(MediaPickerActivity));
            pickerIntent.SetFlags(ActivityFlags.NewTask);
            pickerIntent.PutExtra(MediaPickerActivity.ExtraId, id);
            pickerIntent.PutExtra(MediaPickerActivity.ExtraType, type);
            pickerIntent.PutExtra(MediaPickerActivity.ExtraAction, action);
            pickerIntent.PutExtra(MediaPickerActivity.ExtraTasked, tasked);
            pickerIntent.PutExtra(Intent.ExtraAllowMultiple, true);
            if (options != null)
            {
                pickerIntent.PutExtra(MediaPickerActivity.ExtraPath, options.Directory);
                pickerIntent.PutExtra(MediaStore.Images.ImageColumns.Title, options.Name);

                var vidOptions = options as VideoMediaStorageOptions;
                if (vidOptions != null)
                {
                    pickerIntent.PutExtra(MediaStore.ExtraDurationLimit, (int)vidOptions.DesiredLength.TotalSeconds);
                    pickerIntent.PutExtra(MediaStore.ExtraVideoQuality, (int)vidOptions.Quality);
                }
            }

            return pickerIntent;
        }

        /// <summary>
        /// Gets the request identifier.
        /// </summary>
        /// <returns>Request id as integer.</returns>
        private int GetRequestId()
        {
            var id = _requestId;
            if (_requestId == int.MaxValue)
            {
                _requestId = 0;
            }
            else
            {
                _requestId++;
            }

            return id;
        }

        /// <summary>
        /// Takes the media asynchronous.
        /// </summary>
        /// <param name="type">The type of intent.</param>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns>Task with a return type of MediaFile.</returns>
        /// <exception cref="System.InvalidOperationException">Only one operation can be active at a time.</exception>
        private Task<MediaFile> TakeMediaAsync(string type, string action, MediaStorageOptions options)
        {
            var id = GetRequestId();
            var srcs=new  MediaFile[3];var i = 0;
            var ntcs = new TaskCompletionSource<MediaFile>(id);
            if (Interlocked.CompareExchange(ref _completionSource, ntcs, null) != null)
            {
                throw new InvalidOperationException("Only one operation can be active at a time");
            }

           ((Activity)Forms.Context).StartActivityForResult(Intent.CreateChooser (CreateMediaIntent(id, type, action, options),"choose"),0);

            EventHandler<MediaPickedEventArgs> handler = null;
            handler = (s, e) =>
            {
                var tcs = Interlocked.Exchange(ref _completionSource, null);

                MediaPickerActivity.MediaPicked -= handler;

                if (e.RequestId != id)
                {
                    return;
                }

                if (e.Error != null)
                {
                    tcs.SetException(e.Error);
                }
                else if (e.IsCanceled)
                {
                    tcs.SetCanceled();
                }
                else
                {if(i<3)
                    { srcs[i] = e.Media;i++; }
                    else tcs.SetResult(e.Media);
                }
            };

            MediaPickerActivity.MediaPicked += handler;

            return ntcs.Task;
        }

        

      
    }
}