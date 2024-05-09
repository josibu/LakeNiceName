# LakeNiceName

There is an issue in old Microsoft Word documents which, when changing the text to a symbol font, after changing back to a regular font, all the cahracters are essentialy square symbols.
There is an official article explaining this issue:
https://support.microsoft.com/en-us/topic/wd2002-symbol-characters-are-changed-to-box-characters-1778d1da-7fcb-460d-55bb-e4460538f1ab
This article also contains a macro which is supposed to deal with the issue, unfortunately, however, for me it did not work, probably because the document had tables, text boxes and pictures in it (not sure though if that was the problem).
Instead of trying to understand and fix the macro (I hate VB ;-)), I ended up with the solution here.

1. Save the doc in the new format (docx)
2. Extract the docx file using 7-zip, winrar or similar.
3. Under \word\ of the extracted file, take the path of the document.xml file and provide it to xmlFilePath in the code
4. Run the program
5. Take the modified xml file from where you saved it in the xmlDoc.Save("header1.xml"); line and replace the original file.
6. Zip the file again, make sure that the structure of the new zip is the same as the original file and that it's extension is .docx
7. Open the new docx file and replace &amp;#20; with a space bar
8. Done

Please note that some special characters will not be recovered. You could alter the code to support those, I just didn't have the need for that.
Also, text which in the original file is still readable might get lost - that's also something you could make to code support.

Disclaimer: The code is provided as is without warranties of any kind.
