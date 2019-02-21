Ext.define('SVSClient.view.main.schedule.Schedule', {
    extend: 'Ext.Container',
	xtype: 'schedule',
	requires: [
		'Ext.form.Panel'
	],
    controller: 'main',

    closable: false,
	autoShow: true,
	modal: false,
	draggable: false,
	resizable: false,
	shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,
	cls: 'schedule',
	id: 'schedule',
	itemId: 'schedule',
	height: '100%',
	width: '100%',
	layout: 'hbox',

	//Templates möglich, nicht fertig geworden.
	items:[
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday0',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday1',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday2',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday3',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday4',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday5',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday6',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'monday7',
					handler: 'onClickHour',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday0',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday1',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday2',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday3',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday4',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday5',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday6',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'tuesday7',
					handler: 'onClickHour',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday0',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday1',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday2',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday3',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday4',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday5',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday6',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'wednesday7',
					handler: 'onClickHour',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday0',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday1',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday2',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday3',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday4',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday5',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday6',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'thursday7',
					handler: 'onClickHour',
				},
			]
		},
		{
			xtype: 'container',
			height: '100%',
			width: '20%',
			items:[
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday0',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday1',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday2',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday3',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday4',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday5',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday6',
					handler: 'onClickHour',
				},
				{
					xtype: 'button',
					title: ' ',
					cls: 'schedulePanels',
					width: '100%',
					id: 'friday7',
					handler: 'onClickHour',
				},
			]
		},
    ]
});
