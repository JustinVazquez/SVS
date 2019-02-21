Ext.define('SVSClient.controller.Authentication', {
    extend: 'Ext.app.Controller',
    alias: 'controller.auth',

	sessionName: 'services.sid',
	
    init: function() {
        console.log('Initialized Login Controller! This happens before the Application launch() function is called');
    },

	//Einloggen
    login: function(username, password, callback) {
		console.log("Login authentication called");

    	connection.invoke("Login", username, password).then(function(data){
			var user = data;
			if(user){
				console.log(user);
				Ext.callback(callback.success, callback.scope, user);
			}else{
				Ext.callback(callback.failure, callback.scope, []);
			}
		});
    },

});