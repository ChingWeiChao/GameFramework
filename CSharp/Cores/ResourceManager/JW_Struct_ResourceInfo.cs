using System.Collections;
using System.Collections.Generic;
public class JW_Struct_ResourceInfo
{
    public string Name;
    public List<string> Labels;
    public System.Action<string, object> OnLoadFinished;
}