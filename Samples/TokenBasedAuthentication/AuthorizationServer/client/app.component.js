const BASE = "http://localhost:65423";

class AppComponent {
	constructor($http, $httpParamSerializerJQLike) {
		this.$http = $http;
		this.$httpParamSerializerJQLike = $httpParamSerializerJQLike;
    }

    login() {
    	this.$http({
			url: BASE + "/token",
			method: "post",
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded' // Note the appropriate header
            },
			data: this.$httpParamSerializerJQLike({
                grant_type: "password",
                username: "ori",
                password: "123"
            })
		}).then(res => {
    		this.accessToken = res.data.access_token;

    		console.log(this.accessToken);
        });
    }

    logout() {
		this.accessToken = null;
		this.contacts = [];
    }

    getContacts() {
        this.$http({
            url: BASE + "/api/contact",
            method: "get",
            headers: {
            	Authorization: "Bearer " + this.accessToken
            },
        }).then(res => {
            this.contacts = res.data;

            console.log(this.contacts);
        });
    }
}

appModule.component("myApp", {
	templateUrl: "app.component.html",
	controller: AppComponent,
});
