import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '**',
        redirectTo: 'registration'
    },
    {
        path: 'registration',
        loadChildren: () =>
            import('./pages/registration/registration.module').then(m => m.RegistrationPageModule)
    }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
