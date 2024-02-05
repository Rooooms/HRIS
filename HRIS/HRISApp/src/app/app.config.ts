import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import {MatNativeDateModule} from "@angular/material/core";
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { TokenInterceptor } from './Interceptor/token.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), 
              provideClientHydration(), 
              provideAnimations(), 
              importProvidersFrom(MatNativeDateModule), 
              importProvidersFrom(HttpClientModule), 
              DatePipe,
              {
              provide:HTTP_INTERCEPTORS,
              useClass:TokenInterceptor,
              multi:true
              }
            ] 
};
