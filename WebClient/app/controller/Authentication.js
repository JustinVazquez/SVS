Ext.define('SVSClient.controller.Authentication', {
    extend: 'Ext.app.Controller',
    alias: 'controller.auth',

    listen : {
        controller : {
            'login' : {
                login		: 'login',
            }
        }
    },
	sessionName: 'services.sid',
	
    init: function() {
         console.log('Initialized Login Controller! This happens before the Application launch() function is called');
    },

    login: function(username, password, callback) {
        console.log("Login authentication called")
    	// Authenticate User
		// Ext.Ajax.request({
		// 	method	: 'POST',
		// 	url		: server.Config.getService('auth','login'),
		// 	params	: {
		// 		username	: username,
		// 		password	: password
		// 	},
		// 	success	: function(response, opts) {
		// 		var data = Ext.decode(response.responseText);
		// 		//console.log(data);
		// 		if(data && data.success){
		// 			data.user.sessiontoken = data.user.id;
		// 			server.app.getStore('Login.User').loadRawData(data.user);
		// 			Ext.callback(callback.success, callback.scope, []);
		// 		}else{
		// 			Ext.callback(callback.failure, callback.scope, []);
		// 		}
		// 	},
		// 	failure	: function(response, opts) {
		// 		console.log('server-side failure with status code ' + response.status);
		// 		// Ext.toast('Login failed', false, 'b');
				
		// 		Ext.util.Cookies.clear(this.sessionName);
		// 		Ext.callback(callback.failure, callback.scope, []);
		// 	},
		// 	scope: this
		// });	
    },

});