Ext.define('SVSClient.view.main.MainController', {
    extend: 'Ext.app.ViewController',
    
    alias: 'controller.main',

    //Initiale Funktion für die Main-View.
    //User wird ins Model geschrieben
    //Title wird gefüllt
    init: function(view) {
        var me = this;

        var user = Ext.getCmp('login').getViewModel().get('currentuser');
        me.getViewModel().set('currentuser', user);
        
        Ext.getCmp('usernameField').setTitle(user.name + ' - ' + user.klassenName)

        me.dateSet();
        me.fillSchedule(view);

        //Todo: Dynamisch Farben ändern und styling
    },

    //Datum ins Viewmodel schreiben
    dateSet: function(){
        var currentFullDate = new Date;
        var today = Ext.util.Format.date(currentFullDate, 'Y-m-d');
        this.getViewModel().set('currentdate', today);
    },

    //Kompletten Stundenplan füllen (Immer mit aktueller Woche)
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

                            Ext.getCmp(hour).setText(inputString)
                            Ext.getCmp(hour).addCls('active')
                        }
                        // data.weekdays[day].hours
                    }
                }
            }
            me.fillWeeknotes(data.weekNotes);
        });  
    },

    //Wochennotizen füllen
    fillWeeknotes: function(notes){
        var me = this;
        var noteString = '';

        for(var i = 0; i < notes.length; i++){
            noteString += "- " + notes[i].inhalt + "<br>";
        }
        Ext.getCmp('oldNotes').header.title.setText(noteString)

    },

    
    //Ausloggen..
    onLogout: function(){
        Ext.Msg.confirm('Logging out..', 'Are you sure?', 'onConfirm', this);
    },
    onConfirm: function(){
        location.reload();
    },

    //Neue Notizen ans Backend senden und in die Textbox füllen
    onSendNotes: function(button, event){
        var me = this;
        var newInput = Ext.getCmp('newNotesField').value;
        if(newInput){

            var userClass = me.getViewModel().get('currentuser')['klasse'];
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
    },
    

    //Pop up wird erstellt: Raum, Fach und Status wird übergeben.
    onClickHour: function(button, event){
        var me = this;
        Ext.getCmp('popup').show();
        var currSchedule = me.getViewModel().get('currentschedule');
        var buttonId = button.id;
        var currDay = buttonId.slice(0, -1);
        var currHour = buttonId.substr(buttonId.length - 1);
        var dayObj = currSchedule[currDay];
        var hourObj = dayObj[currHour];
        if(dayObj.length != 0){
            var currSubject = hourObj.fach;
            var currRoom = hourObj.raum;
            var currStatus = hourObj.status;
            if(currSubject){
                Ext.getCmp('subject').setValue(currSubject);
            }
            if(currRoom){
                Ext.getCmp('room').setValue(currRoom);
            }
            if(currStatus){
                Ext.getCmp('status').setValue(currStatus);
            }
        } 
    },

    //Änderungen werden ans Backend gegeben und gespeichert
    //Bisher nur Status möglich
    //Testweise: StundenId: 10, Status 1 (Entfall)
    //Nicht vollständig
    sendChanges: function(){
        var scheduleHour = 10
        var statusId = 1;

        connection.invoke("changeStatus", scheduleHour, statusId).then(function(send){
            if(send){
                Ext.toast("Send changes..");
                location.reload();
            }else{
                Ext.toast("Error sending message..");
            }
        });
    }

});
