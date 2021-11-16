# GVMLClipboardUtils

While debugging copy/paste scenarios for Office graphical content, we need to deal with gvml which is a cross office app format for drawing content. Investigating gvml content on clipboard is difficult and often desires to get the contents of gvml from clipboard into a local zip file, which can then be uncompressed and looked into.

ExtractGVMLFromClipboard facilitates debugging scenarios where we need to see how the app is converting the drawing content to gvml.

The other scenario is to see how the gvml content is pasted into the app. This also is needed when we need to make changes to gvml and see how the content gets pasted in the office apps. PutGVMLToClipboard does this by taking in a gvml zip file and putting it on the clipboard. This enables the user to invoke paste on the office apps and observe the rendering/persistence of the gvml content.

This solution contains below Utilities

- ExtractGVMLFromClipboard - This extracts the gvml content from the clipboard (if present) and copies the content as zip in user's download folder.
- PutGVMLToClipboard - This given path to a gvml zip, puts the gvml content on the clip board.
