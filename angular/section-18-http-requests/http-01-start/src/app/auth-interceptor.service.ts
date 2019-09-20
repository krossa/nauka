import { HttpInterceptor, HttpRequest, HttpHandler, HttpEventType } from '@angular/common/http';
import { tap } from 'rxjs/operators';

export class AuthInterceptorService implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler) {
        const newRequest = req.clone(
            {
                headers: req.headers.append('auth', 'val')
            }
        );
        return next.handle(newRequest).pipe(tap(event => {
            if (event.type === HttpEventType.Response) {
                // console.log('RESPONSE ARRIVED body: ');
                // console.log(event.body);
            }
        }));
    }
}
