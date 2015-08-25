using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ldj")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ldj")]
[assembly: AssemblyCopyright("Copyright ©  2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("06c5b957-1c9e-48f2-afdb-eeebdc58d88a")]

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
[assembly: AssemblyVersion("1.5.1.1")]
[assembly: AssemblyFileVersion("1.5.1.1")]

/*1.5 20120731
 * 限定查找左中括号的范围,防止聊天框的中括号干扰
 * 种植恢复原来方式,直接找稻草人的方式还需测试
 * 1.5.1 20120828
 * 自动注册COM,弃用regsvr32,直接call com中的DllRegisterServer进行注册
 * 1.5.1.1 20121101
 * 入帮会NPC上的帮会列表距离改成23,原来22
*/
