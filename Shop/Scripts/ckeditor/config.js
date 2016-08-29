/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.language = 'vi'; //Tiếng Việt

    config.filebrowserBrowseUrl = '~/Scripts/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '~/Scripts/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '~/Scripts/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '~/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '~/Uploat';
    config.filebrowserFlashUploadUrl = '~/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '~/Scripts/ckfinder/');

};
