using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using EcuriesDuLoupWin.utils.menu;

namespace RegistryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("======");
                foreach (String arg in args)
                {
                    Console.WriteLine("-"+arg+"-");
                }
                Console.WriteLine("======");
                String action = args[0];
                if (action.Equals("-add"))
                {
                    String directory = args[1];
                    String key = args[2];
                    String value = args[3];
                    
                    Program.Add(directory, key, value);
                }
                else if (action.Equals("-remove"))
                {
                    String directory = args[1];
                    Program.Remove(directory);
                }
                else if (action.Equals("-addimages"))
                {
                    String pathOfApplcation = args[1];
                    ContextMenuManagerWin7 contextualMenu = new ContextMenuManagerWin7(pathOfApplcation);
                    contextualMenu.RemoveEcurieDuLoupInContextualsMenu();
                    contextualMenu.AddEcurieDuLoupInContextualsMenu();
                }
                else if (action.Equals("-removeimages"))
                {

                    String pathOfApplcation = args[1];
                    ContextMenuManagerWin7 contextualMenu = new ContextMenuManagerWin7(pathOfApplcation);
                    contextualMenu.RemoveEcurieDuLoupInContextualsMenu();
                }
                else
                {
                    Console.WriteLine("erreur");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Add(String directory, String key, String value)
        {
            RegistryWindows registry = new RegistryWindows(directory, key, value);
            registry.Add();
        }

        private static void Remove(String directory)
        {
            RegistryWindows registry = new RegistryWindows(directory);
            registry.Remove();
        }
    }
}
