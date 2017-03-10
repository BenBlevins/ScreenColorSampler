using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

public enum Mode
{
	Continuous,
	CtrlKey,
}

public enum Format
{
	Integer,
	Hex
}

public class Settings
{
	public Mode Mode = Mode.Continuous;
	public bool AlwaysOnTop = true;
	public int SampleSize = 1;
	public int Zoom = 3;
	public bool AutoCopy = true;
	public Format Format = Format.Integer;
	public List<int> Colors = new List<int>();
	public int MaxColorsHistory = 32;

	public Point WindowLocation = new Point(100, 100);
	public Size WindowSize = new Size(1000, 500);

	public static Settings Load()
	{
		try
		{
			Settings s;
			XmlFileLoad(out s, FileName);
			return s;
		}
		catch
		{
			return new Settings();
		}
	}

	public static void Save(Settings s)
	{
		XmlFileSave(s, FileName);
	}

	static void XmlFileSave<T>(T o, string filename)
	{
		using (TextWriter outputStream = new StreamWriter(filename))
		{
			XmlSerializer xml = new XmlSerializer(typeof(T));
			xml.Serialize(outputStream, o);
		}
	}

	static void XmlFileLoad<T>(out T o, string filename)
	{
		using (TextReader outputStream = new StreamReader(filename))
		{
			XmlSerializer xml = new XmlSerializer(typeof(T));
			o = (T)xml.Deserialize(outputStream);
		}
	}

	static string FileName
	{
		get
		{
			return Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "xml");
		}
	}
}

