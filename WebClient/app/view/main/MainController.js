/**
 * This class is the controller for the main view for the application. It is specified as
 * the "controller" of the Main view class.
 */
Ext.define('SVSClient.view.main.MainController', {
    extend: 'Ext.app.ViewController',
    
    alias: 'controller.main',

    init: function(view) {
        var me = this;

        var user = Ext.getCmp('login').getViewModel().get('currentuser');
        me.getViewModel().set('currentuser', user);
        
        Ext.getCmp('usernameField').setTitle(user.name + ' - ' + user.klassenName)

        me.dateSet();
        me.fillSchedule(view);

        //Dynamically look up which time and day it is, add cls!!
    },

    dateSet: function(){
        var currentFullDate = new Date;
        var today = Ext.util.Format.date(currentFullDate, 'Y-m-d');
        this.getViewModel().set('currentdate', today);
    },

    fillSchedule: function(view){
        var me = this;
        
        //Ersten Tag und letzten Tag der Woche bekommen
        var curr = new Date;
        var first = curr.getDate()-curr.getDay()+1;
        var last = first+4;
        var currMS = Date.now();
        var firstday = new Date(curr.setDate(first)).toUTCString();
        var lastday = new Date(curr.setDate(last)).toUTCString();

        Ext.getCmp('datePanel').title = Ext.util.Format.date(firstday) + ' - ' + Ext.util.Format.date(lastday);
        
        var userClass = me.getViewModel().get('currentuser')['klasse'];
        var currDate = me.getViewModel().get('currentdate');
        
        connection.invoke("GetStundenplan", userClass, currDate).then(function(data){
            console.log(data);
            me.getViewModel().set('currentschedule', data);
            var weekdays = ['monday', 'tuesday', 'wednesday', 'thursday', 'friday'];
            for(var day = 0; day < 5; day++){
                if(data[weekdays[day]].length != 0){
                    for(var hours = 0; hours < 8; hours++){
                        var hour = weekdays[day] + hours;
                        
                        if(data[weekdays[day]][hours] && data[weekdays[day]][hours].fach_ID != 0){
                            var inputString = data[weekdays[day]][hours].fach + '<br>' + data[weekdays[day]][hours].raum;
                            Ext.getCmp(hour).header.title.setText(inputString)
                            Ext.getCmp(hour).addCls('active')
                        }
                        // data.weekdays[day].hours
                    }
                }
            }
            me.fillWeeknotes(data.weekNotes);
        });  
    },

    fillWeeknotes: function(notes){
        var me = this;
        var noteString = '';

        for(var i = 0; i < notes.length; i++){
            noteString += "- " + notes[i].inhalt + "<br>";
        }
        Ext.getCmp('oldNotes').header.title.setText(noteString)

    },

    onConfirm: function (choice) {
        if (choice === 'yes') {
            location.reload();
        }
    },
    
    onLogout: function(){
        Ext.Msg.confirm('Logging out..', 'Are you sure?', 'onConfirm', this);
    },

    onSendNotes: function(button, event){
        var me = this;
        // Neue Notizen an 
        // var userClass = me.getViewModel().get('currentuser').get('class');
        var userClass = me.getViewModel().get('currentuser')['klasse'];
        var newInput = Ext.getCmp('newNotesField').value;
        var currDate = me.getViewModel().get('currentdate');

    	connection.invoke("addWeekNote", userClass, newInput, currDate).then(function(send){
			if(send){
                //Füllt die Textbox mit den neuen Notizen
                var formattedNew = "- " + newInput + "<br>"; 
                var oldInput = Ext.getCmp('oldNotes').header.title.getText();
                Ext.getCmp('oldNotes').header.title.setText(oldInput + formattedNew);
                Ext.getCmp('newNotesField').setValue("");
                Ext.toast("Sending message..");
			}else{
				Ext.toast("Error sending message..");
			}
		});
    }
});
