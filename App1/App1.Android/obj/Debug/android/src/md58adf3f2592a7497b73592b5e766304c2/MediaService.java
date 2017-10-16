package md58adf3f2592a7497b73592b5e766304c2;


public class MediaService
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App1.Droid.MediaService, App1.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MediaService.class, __md_methods);
	}


	public MediaService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MediaService.class)
			mono.android.TypeManager.Activate ("App1.Droid.MediaService, App1.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
