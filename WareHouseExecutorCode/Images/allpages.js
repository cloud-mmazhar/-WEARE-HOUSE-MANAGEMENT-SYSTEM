var win1='';
var blnOpen = false;

function LinkColor(color)
{
	if (document.all && color!="")
	{
		window.event.srcElement.style.color=color;
	}
}

//function to open new window
function openWindow(sURL)
{
	closeWindow();
	blnOpen=true;
	win1 = window.open(sURL, 'NewWindow', "width=500,height=500,scrollbars=yes,toolbar=no,left=312,top=0");
}

//function to close window
function closeWindow()
{
	if ((blnOpen==true) && (!win1.closed))
		{
		win1.close();	
		}
	blnOpen=false;
}

function launchwindow (val)
{
window.open(val,null,"height=480,width=640,status=yes,toolbar=yes,menubar=yes,location=yes,resizable=yes,scrollbars=yes,fullscreen=no,top=0");
}


/*********************************************************************
Object to do Url Encoding and Decoding */

var Url = {

	// public method for url encoding
	encode : function (string) {
		return escape(this._utf8_encode(string));
	},

	// public method for url decoding
	decode : function (string) {
		return this._utf8_decode(unescape(string));
	},

	// private method for UTF-8 encoding
	_utf8_encode : function (string) {
		string = string.replace(/\r\n/g,"\n");
		var utftext = "";

		for (var n = 0; n < string.length; n++) {

			var c = string.charCodeAt(n);

			if (c < 128) {
				utftext += String.fromCharCode(c);
			}
			else if((c > 127) && (c < 2048)) {
				utftext += String.fromCharCode((c >> 6) | 192);
				utftext += String.fromCharCode((c & 63) | 128);
			}
			else {
				utftext += String.fromCharCode((c >> 12) | 224);
				utftext += String.fromCharCode(((c >> 6) & 63) | 128);
				utftext += String.fromCharCode((c & 63) | 128);
			}

		}

		return utftext;
	},

	// private method for UTF-8 decoding
	_utf8_decode : function (utftext) {
		var string = "";
		var i = 0;
		var c = c1 = c2 = 0;

		while ( i < utftext.length ) {

			c = utftext.charCodeAt(i);

			if (c < 128) {
				string += String.fromCharCode(c);
				i++;
			}
			else if((c > 191) && (c < 224)) {
				c2 = utftext.charCodeAt(i+1);
				string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
				i += 2;
			}
			else {
				c2 = utftext.charCodeAt(i+1);
				c3 = utftext.charCodeAt(i+2);
				string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
				i += 3;
			}

		}

		return string;
	}

}


/*************************************************************************/
