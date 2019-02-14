/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('SVSClient.view.main.MainController', {
    extend: 'Ext.app.ViewController',

	// listen: {
	// 	// listen to other controller events
	// 	controller: {
	// 		'login': {
	// 			onMainLoad: 'onMainLoad',
    //         },
    //     }
    // },
    
    alias: 'controller.main',

    init: function(view) {
        var curr = new Date; // get current date
        var first = curr.getDate() - curr.getDay() +1; // First day is the day of the month - the day of the week
        var last = first + 4; // last day is the first day + 6
        
        var firstday = new Date(curr.setDate(first)).toUTCString();
        var lastday = new Date(curr.setDate(last)).toUTCString();
        
        Ext.getCmp('datePanel').title = Ext.util.Format.date(firstday) + ' - ' + Ext.util.Format.date(lastday);
        

        

    },

    onItemSelected: function (sender, record) {
        Ext.Msg.confirm('Confirm', 'Are you sure?', 'onConfirm', this);
    },

    onConfirm: function (choice) {
        if (choice === 'yes') {
            //
        }
    },


});
