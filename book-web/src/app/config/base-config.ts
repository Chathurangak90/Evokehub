import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseConfig {
  public ApiBaseUrl: string = environment.apiBaseUrl;
}
