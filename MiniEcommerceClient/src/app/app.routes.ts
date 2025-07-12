import { Routes } from '@angular/router';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { LayoutsComponent } from './Components/layouts/layouts.component';
import { HomeComponent } from './Components/home/home.component';
import { ShoppingCartsComponent } from './Components/shopping-carts/shopping-carts.component';
import { OrdersComponent } from './Components/orders/orders.component';

export const routes: Routes = [

    {
        path:"register",
        component:RegisterComponent
    },
    {
        path:"login",
        component:LoginComponent
    },
     {
        path:"",
        component:LayoutsComponent,
        children:[
            {
                path:"",
                component:HomeComponent
            },
            {
                path:"shopping-carts",
                component:ShoppingCartsComponent
            },
            {
                path:"orders",
                component:OrdersComponent
            }
        ]
    },
    

];
