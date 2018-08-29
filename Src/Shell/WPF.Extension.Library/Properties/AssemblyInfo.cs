using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("TroopBattle.WPF.Library")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("TroopBattle.WPF.Library")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("0d15300f-1ffe-48aa-bab7-42380ca26234")]

[assembly: XmlnsDefinition("http://ddomain.com/WPFExtension", "WPF.Extension.Library.Presentation")]
[assembly: XmlnsDefinition("http://ddomain.com/WPFExtension", "WPF.Extension.Library")]
[assembly: XmlnsDefinition("http://ddomain.com/WPFExtension", "WPF.Extension.Library.Controls")]
[assembly: XmlnsDefinition("http://ddomain.com/WPFExtension", "WPF.Extension.Library.Converters")]
[assembly: XmlnsPrefix("http://ddomain.com/WPFExtension", "wel")]

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
