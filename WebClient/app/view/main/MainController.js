/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('SVSClient.view.main.MainController', {
    extend: 'Ext.app.ViewController',
    
    alias: 'controller.main',

    init: function(view) {
        var me = this;

        me.fillSchedule(view);
        //Dynamically look up which time and day it is, add cls!!
    },

    fillSchedule: function(view){
        var me = this;
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
            me.fillWeeknotes(data.wochenNotiz);
        });  
    },

    fillWeeknotes: function(notes){
        var me = this;
        var noteString = '';
        for(var i = 0; i < notes.length; i++){
            noteString += "- " + notes[i].text + "<br>";
        }
        Ext.getCmp('oldNotes').header.title.setText(noteString)

    },

    onConfirm: function (choice) {
        if (choice === 'yes') {
            location.reload();
            console.log("Loggin out...")
        }
    },
    
    onLogout: function(){
        Ext.Msg.confirm('Logging out..', 'Are you sure?', 'onConfirm', this);
    },

    onSendNotes: function(button, event){
        var me = this;
        //Neue Notizen an 
        // var userClass = me.getViewModel().get('currentuser').get('class');
        var userClass = "1";
        var newInput = Ext.getCmp('newNotesField').value;
    	connection.invoke("addWeekNote", userClass, newInput).then(function(send){
			
			if(send){
                //Füllt die Textbox mit den neuen Notizen
                var formattedNew = "- " + newInput + "<br>"; 
                var oldInput = Ext.getCmp('oldNotes').header.title.getText();
                Ext.getCmp('oldNotes').header.title.setText(oldInput + formattedNew);
                Ext.getCmp('newNotesField').setValue("");
                Ext.toast("Sending message..");
				console.log(user);
			}else{
				Ext.toast("Error sending message..");
			}
		});
    }
});
