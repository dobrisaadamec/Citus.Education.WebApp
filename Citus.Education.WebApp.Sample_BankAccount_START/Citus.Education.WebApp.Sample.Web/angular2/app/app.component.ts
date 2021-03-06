import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'my-app',
    //template: '<img [src]="logoUrl" /><h1>{{pageTitle}}</h1><h2>{{pero}}</h2>'
    templateUrl: 'app.component.html'
})
export class AppComponent {
    pageTitle: string = "Nešto nešto";
    pero: number = 123;
    logoUrl: string = "https://raiffeisenbank.ba/templates/default/users_data/slike/logo_rbbh.jpg_van_bih.jpg";
    getVrijeme(): string {
        return new Date().toLocaleDateString();
    }
    public person = { firstName : 'Super', lastName : 'Men'}
}
