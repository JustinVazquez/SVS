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
        var currMS = Date.now();
        
        var firstday = new Date(curr.setDate(first)).toUTCString();
        var lastday = new Date(curr.setDate(last)).toUTCString();
        Ext.getCmp('datePanel').title = Ext.util.Format.date(firstday) + ' - ' + Ext.util.Format.date(lastday);
        
        connection.invoke("TestWoche").then(function(data){
            console.log(data);
            var weekdays = ['monday', 'tuesday', 'wednesday', 'thursday', 'friday'];
            for(var day = 0; day < 5; day++){
                for(var hours = 0; hours < 8; hours++){
                    var hour = weekdays[day] + hours;

                    if(data[weekdays[day]]){
                        if(data[weekdays[day]][hours].fach_ID != 0){
                            var inputString = data[weekdays[day]][hours].fach + '<br>' + data[weekdays[day]][hours].raum;
                            Ext.getCmp(hour).header.title.setText(inputString)
                            Ext.getCmp(hour).addCls('active')
                            console.log("Active: " + hour);
                        }
                    }


                    // data.weekdays[day].hours
                }
            }

		});
        

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
