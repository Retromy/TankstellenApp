using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TankstellenApp
{
    public static class VariablenClass
    {
        // speichert ApiKeys als Umgebungsvariablen 
        public static void SaveVariable(string VariableName, TextBox txtBox) 
        {
            Environment.SetEnvironmentVariable(VariableName, txtBox.Text, EnvironmentVariableTarget.User);
        }
        // lädt die Werte der Umgebungsvariablen
        public static string GetUserEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
        }
    }
}
