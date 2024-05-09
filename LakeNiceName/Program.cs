using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace LakeNiceName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Replace "nodeToReplace" with your specific values
            string nodeToReplace = "w:t";

            string xmlFilePath = @"C:\temp\Word problem\Original - Copy\word\header1.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            ReplaceNodeText(xmlDoc.DocumentElement, nodeToReplace);

            // Save the modified XML to a new file
            xmlDoc.Save("header1.xml");

            Console.WriteLine("Replacement completed successfully.");
        }

        static void ReplaceNodeText(XmlNode node, string nodeNameToReplace)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                // Check if the current node's name matches the target node name
                if (node.Name == nodeNameToReplace)
                {
                    // Replace the inner text of the node with the replacement text
                    node.InnerText = convertText(node.InnerText).Replace(" ", "&#20;");
                }
            }

            // Recursively call this method for each child node
            foreach (XmlNode childNode in node.ChildNodes)
            {
                ReplaceNodeText(childNode, nodeNameToReplace);
            }
        }

        static string convertText(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            Console.WriteLine(string.Join("|", bytes.Select(a => char.ConvertFromUtf32(a))));
            return char.ConvertFromUtf32(bytes.First());
        }
    }
}
