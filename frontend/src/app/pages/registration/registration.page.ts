import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/auth.service';
import { IonInput } from '@ionic/angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.page.html',
    styleUrls: ['./registration.page.scss'],
})

export class RegistrationPage implements OnInit {

    public registerForm: FormGroup;

    private EMAIL_PATTERN: string;

    constructor(
        public router: Router,
        public formBuilder: FormBuilder,
        public authService: AuthenticationService,
    ) {
        this.EMAIL_PATTERN = '[A-Za-z0-9._%+-]{2,}@[a-zA-Z-_.]{2,}[.]{1}[a-zA-Z]{2,}';

        this.registerForm = this.formBuilder.group({
            name: ['', [Validators.required, Validators.minLength(4)]],
            email: ['', [Validators.required, Validators.pattern(this.EMAIL_PATTERN)]],
            password: ['', [Validators.required, Validators.minLength(4)]],
            role: ['0', [Validators.required]],
        });
    }

    ngOnInit() { }

    signUp(email: IonInput, password: IonInput): void {
        this.authService.RegisterUser(email.value, password.value)
            .then((res) => {
                // Do something here
            }).catch((error) => {
                window.alert(error.message);
            });
    }

}