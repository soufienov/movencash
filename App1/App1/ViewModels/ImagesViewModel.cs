
using App1.Views;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
namespace App1.ViewModels
{
    [ViewType(typeof(Images))]
    class ImagesViewModel: XLabs.Forms.Mvvm.ViewModel
    {

        /// <summary>
        /// The _scheduler.
        /// </summary>
        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        /// <summary>
        /// The picture chooser.
        /// </summary>
        private App1.Controls.IMediaPicker _mediaPicker;

        /// <summary>
        /// The image source.
        /// </summary>
        public ImageSource[] _imageSource;

        /// <summary>
        /// The video info.
        /// </summary>
        private string _videoInfo;

        /// <summary>
        /// The take picture command.
        /// </summary>
        private Command _takePictureCommand;

        /// <summary>
        /// The select picture command.
        /// </summary>
        private Command _selectPictureCommand;

        /// <summary>
        /// The select video command.
        /// </summary>
        private Command _selectVideoCommand;

        private string _status;


        ////private CancellationTokenSource cancelSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraViewModel" /> class.
        /// </summary>
        public ImagesViewModel()
        { _imageSource = new ImageSource[6] {"camera.png", "camera.png", "camera.png", "camera.png", "camera.png", "camera.png" };
            Setup();
                
        }

        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        /// <value>The image source.</value>
        /// 
        #region imagesources
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource[0] ?? "camera.png";
            }
            set
            {
                SetProperty(ref _imageSource[0], value);
            }
        }
        public ImageSource ImageSource1
        {
            get
            {
                return _imageSource[1] ?? "camera.png";
            }
            set
            {
                SetProperty(ref _imageSource[1], value);
            }
        }
        public ImageSource ImageSource2
        {
            get
            {
                return _imageSource[2] ?? "camera.png";
            }
            set
            {
                SetProperty(ref _imageSource[2], value);
            }
        }
        public ImageSource ImageSource3
        {
            get
            {
                return _imageSource[3] ?? "camera.png";
            }
            set
            {
                SetProperty(ref _imageSource[3], value);
            }
        }
        public ImageSource ImageSource4
        {
            get
            {
                return _imageSource[4]??"camera.png";
            }
            set
            {
                SetProperty(ref _imageSource[4], value);
            }
        }
        public ImageSource ImageSource5
        {
            get
            {
                return _imageSource[5] ?? "camera.png";
            }
            set
            {
                SetProperty(ref _imageSource[5], value);
            }
        }
        #endregion imagesources
       
        /// <summary>
        /// Gets or sets the video info.
        /// </summary>
        /// <value>The video info.</value>
        public string VideoInfo
        {
            get
            {
                return _videoInfo;
            }
            set
            {
                SetProperty(ref _videoInfo, value);
            }
        }

        /// <summary>
        /// Gets the take picture command.
        /// </summary>
        /// <value>The take picture command.</value>
        public Command TakePictureCommand
        {
            get
            {
                return _takePictureCommand ?? (_takePictureCommand = new Command(
                                                                       async () => await TakePicture(),
                                                                       () => true));
            }
        }

        /// <summary>
        /// Gets the select video command.
        /// </summary>
        /// <value>The select picture command.</value>
        public Command SelectVideoCommand
        {
            get
            {
                return _selectVideoCommand ?? (_selectVideoCommand = new Command(
                                                                       async () => await SelectVideo(),
                                                                       () => true));
            }
        }

        /// <summary>
        /// Gets the select picture command.
        /// </summary>
        /// <value>The select picture command.</value>
        public Command SelectPictureCommand
        {
            get
            {
                return _selectPictureCommand ?? (_selectPictureCommand = new Command(
                                                                           async () => await SelectPicture(),
                                                                           () => true));
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status
        {
            get { return _status; }
            private set { SetProperty(ref _status, value); }
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        private void Setup()
        {
            if (_mediaPicker != null)
            {
                return;
            }
           
            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            var mp = DependencyService.Get<App1.Controls.IMediaPicker>();
            _mediaPicker = mp ;
        }

        /// <summary>
        /// Takes the picture.
        /// </summary>
        /// <returns>Take Picture Task.</returns>
        private async Task<MediaFile> TakePicture()
        {
            Setup();

            ImageSource = null;

            return await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Status = t.Exception.InnerException.ToString();
                }
                else if (t.IsCanceled)
                {
                    Status = "Canceled";
                }
                else
                {
                    var mediaFile = t.Result;

                    ImageSource = ImageSource.FromStream(() => mediaFile.Source);

                    return mediaFile;
                }

                return null;
            }, _scheduler);
        }

        /// <summary>
        /// Selects the picture.
        /// </summary>
        /// <returns>Select Picture Task.</returns>
        private async Task SelectPicture()
        {
            Setup();
            ImageSource[] resultSource= new ImageSource[6];
            var options = new CameraMediaStorageOptions
            {
                DefaultCamera = CameraDevice.Front,
                MaxPixelDimension = 400
            };
            ImageSource = null;
          
                 try{
                 await _mediaPicker.SelectPhotoAsync(options).ContinueWith((mediaFile) => {
                   ImageSource5 = ImageSource.FromStream(() => mediaFile.Result[5].Source);
                     ImageSource4 = ImageSource.FromStream(() => mediaFile.Result[4].Source);
                     ImageSource3 = ImageSource.FromStream(() => mediaFile.Result[3].Source);
                     ImageSource2 = ImageSource.FromStream(() => mediaFile.Result[2].Source);
                     ImageSource = ImageSource.FromStream(() =>  mediaFile.Result[0].Source);
                    
                 });
               // var k=mediaFile.Length;
               /* switch (k)
                {
                    case 0: break;
                    case 1:ImageSource= ImageSource.FromStream(() => mediaFile[0].Source);break;
                    case 2: ImageSource = ImageSource.FromStream(() => mediaFile[0].Source); ImageSource1 = ImageSource.FromStream(() => mediaFile[1].Source); break;
                    case 3: ImageSource2 = ImageSource.FromStream(() => mediaFile[2].Source); ImageSource = ImageSource.FromStream(() => mediaFile[0].Source);
                        ImageSource1 = ImageSource.FromStream(() => mediaFile[1].Source); break;
                    case 4: ImageSource3 = ImageSource.FromStream(() => mediaFile[3].Source); ImageSource = ImageSource.FromStream(() => mediaFile[2].Source); ImageSource.FromStream(() => mediaFile[0].Source);
                        ImageSource1 = ImageSource.FromStream(() => mediaFile[1].Source); break;
                    case 5: ImageSource4 = ImageSource.FromStream(() => mediaFile[4].Source); ImageSource3 = ImageSource.FromStream(() => mediaFile[3].Source); ImageSource = ImageSource.FromStream(() => mediaFile[2].Source); ImageSource.FromStream(() => mediaFile[0].Source);
                        ImageSource1 = ImageSource.FromStream(() => mediaFile[1].Source); break;
                    case 6: ImageSource5 = ImageSource.FromStream(() => mediaFile[5].Source); ImageSource4 = ImageSource.FromStream(() => mediaFile[4].Source); ImageSource3 = ImageSource.FromStream(() => mediaFile[3].Source); ImageSource = ImageSource.FromStream(() => mediaFile[2].Source); ImageSource.FromStream(() => mediaFile[0].Source);
                        ImageSource1 = ImageSource.FromStream(() => mediaFile[1].Source); break;
                    default:
                       break;
                }
                */

                }
            catch (System.Exception ex)
                {
                    Status = ex.Message;
                } 
        }

        /// <summary>
        /// Selects the video.
        /// </summary>
        /// <returns>Select Video Task.</returns>
        private async Task SelectVideo()
        {
            Setup();

            //TODO Localize
            VideoInfo = "Selecting video";

            try
            {
                var mediaFile = await _mediaPicker.SelectVideoAsync(new VideoMediaStorageOptions());

                //TODO Localize
                VideoInfo = mediaFile != null
                                ? string.Format("Your video size {0} MB", ConvertBytesToMegabytes(mediaFile[0].Source.Length))
                                : "No video was selected";
            }
            catch (System.Exception ex)
            {
                if (ex is TaskCanceledException)
                {
                    //TODO Localize
                    VideoInfo = "Selecting video canceled";
                }
                else
                {
                    VideoInfo = ex.Message;
                }
            }
        }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}