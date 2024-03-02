import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, delay, finalize } from 'rxjs';
import { BusyService } from '../_services/busy.service';

@Injectable()
export class loadingInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService) { }

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.busyService.busy();

    return next.handle(req).pipe(
      delay(1000),
      finalize(() => {
        this.busyService.idle()
      })
    )
  }
}
