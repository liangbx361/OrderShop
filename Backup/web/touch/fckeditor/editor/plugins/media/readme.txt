
/*********************************************************************************************************/
/**
 * Media Plugin for FCKeditor (Support: Lajox ; Email: lajox@19www.com)
 * Download: http://code.google.com/p/lajox
 */
/*********************************************************************************************************/

Help: 

1. Upload media folder to fckeditor/editor/plugins/ 

2. Modify Fckeditor/fckconfig.js Content:
    Increase the line of code:
    	FCKConfig.Plugins.Add( 'media','en,zh-cn') ; //Media Plugin

3. Add a value 'Media' to FCKConfig.ToolbarSets

Note: 
If your FCKeditor Open Media upload feature set is not the case, please refer to the Advanced Help
 
=========================================================================================================
Advanced Help：

1. Upload media folder to fckeditor/editor/plugins/ 

2. Modify Fckeditor/fckconfig.js Content:
    Increase the line of code:
    	FCKConfig.Plugins.Add( 'media','en,zh-cn') ; //Media Plugin

3. Add a value 'Media' to FCKConfig.ToolbarSets

4. Modify Fckeditor/fckconfig.js Content again,
	increase the contents of code:


/*************Add MediaBrowser begin******************/
FCKConfig.MediaBrowser = true ;

FCKConfig.MediaBrowserURL = FCKConfig.BasePath + 'filemanager/browser/default/browser.html?Type=Media&Connector=' + encodeURIComponent( FCKConfig.BasePath + 'filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension ) ;

FCKConfig.MediaBrowserWindowWidth  = FCKConfig.ScreenWidth * 0.7 ; //70% ;

FCKConfig.MediaBrowserWindowHeight = FCKConfig.ScreenHeight * 0.7 ; //70% ;

FCKConfig.MediaUpload = true ;

FCKConfig.MediaUploadURL = FCKConfig.BasePath + 'filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension + '?Type=Media' ;

FCKConfig.MediaUploadAllowedExtensions = ".(mp3|wma|wav|wmv|mov|avi|swf|flv|mp4|mpg|rm|rmvb)$" ; // empty for all

FCKConfig.MediaUploadDeniedExtensions = "" ;     // empty for no one
/*************Add MediaBrowser end******************/



5：Modify fckeditor/editor/filemanager/connectors/php/config.php

Search the line:
$Config['UserFilesPath'] = '/userfiles/'  

Modify '/userfiles/'    e.g.  '/attachment/'


Modify the following code:
--
Change the line 

$Config['QuickUploadPath']['File']  = $Config['UserFilesPath'] ;

for:

$Config['QuickUploadPath']['File']  = $Config['UserFilesPath'] . 'file/' ;

Change the line

$Config['QuickUploadPath']['Image']  = $Config['UserFilesPath'] ;

for:

$Config['QuickUploadPath']['Image']  = $Config['UserFilesPath']  . 'image/';

Change the line 

$Config['QuickUploadPath']['Flash']  = $Config['UserFilesPath'] ;

for:

$Config['QuickUploadPath']['Flash']  = $Config['UserFilesPath']  . 'flash/';

Change the line

$Config['QuickUploadPath']['Media']  = $Config['UserFilesPath'] ;

for:

$Config['QuickUploadPath']['Media']  = $Config['UserFilesPath']  . 'media/';


---------------------------------------------------------------------------------------


