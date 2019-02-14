Ext.define('SVSClient.view.main.Main', {
    extend: 'Ext.window.Window',
	xtype: 'app-main',
	requires: [
		// 'SVSClient.view.login.LoginController',
		// 'SVSClient.view.login.LoginModel',
		// 'SVSClient.view.main.Main',
		'Ext.form.Panel'
	],
    controller: 'main',
    viewModel: 'main',
    closable: false,
	autoShow: true,
	modal: false,
	draggable: false,
	resizable: false,
	shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,
	// width: 300,
	cls: 'main',
	id: 'main',
	itemId: 'main',
	height: '100%',
	width: '100%',

    items: [
    
	{
		xtype: 'panel',
		height: 50,
		width: '100%',
		title: '© Timon Minich, Luca Tecce, Justin Vazquez, Luca Tecce, Christopher Urban',
		// title: 'Randa<span class="super">&reg;</span> QuickStep<span class="super">&trade;</span>',
		cls: 'authors',
	}]
});
