package md5a104545e4d19c4ffe9ec3d5074a3b979;


public class AuthenticatorUiOptions
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_ReadObject:(Ljava/io/ObjectInputStream;)V:__export__\n" +
			"n_WriteObject:(Ljava/io/ObjectOutputStream;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Auth.AuthenticatorUiOptions, Xamarin.Auth, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null", AuthenticatorUiOptions.class, __md_methods);
	}


	public AuthenticatorUiOptions () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AuthenticatorUiOptions.class)
			mono.android.TypeManager.Activate ("Xamarin.Auth.AuthenticatorUiOptions, Xamarin.Auth, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	private void readObject (java.io.ObjectInputStream p0) throws java.io.IOException, java.lang.ClassNotFoundException
	{
		n_ReadObject (p0);
	}

	private native void n_ReadObject (java.io.ObjectInputStream p0);


	private void writeObject (java.io.ObjectOutputStream p0) throws java.io.IOException, java.lang.ClassNotFoundException
	{
		n_WriteObject (p0);
	}

	private native void n_WriteObject (java.io.ObjectOutputStream p0);

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
