import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType } from '@angular/common/http';
import { map, catchError, tap } from 'rxjs/operators';
import { Post } from './post.model';
import { Subject, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PostsService {
    error = new Subject<string>();
    created = new Subject<{ name: string }>();

    constructor(private http: HttpClient) { }

    createPost(postData: Post) {
        // Send Http request
        return this.http
            .post<{ name: string }>(
                'https://ng-complet-guid.firebaseio.com/posts.json',
                postData,
                {
                    observe: 'response'
                }
            ).subscribe(responseData => {
                this.created.next(responseData.body);
            },
                error => {
                    this.error.next(error.message);
                });
    }

    fetchPosts() {
        let queryParams = new HttpParams();
        queryParams = queryParams.append('print', 'pretty');
        queryParams = queryParams.append('custom', 'key');

        return this.http.get<{ [key: string]: Post }>(
            'https://ng-complet-guid.firebaseio.com/posts.json',
            {
                headers: new HttpHeaders({ 'Custom-Header': 'Hello' }),
                params: queryParams,
                responseType: 'json'
            }
        )
            .pipe(
                map(responseData => {
                    const result: Post[] = [];
                    for (const key in responseData) {
                        if (responseData.hasOwnProperty(key)) {
                            result.push({ ...responseData[key], id: key });
                        }
                    }
                    return result;
                }),
                catchError(er => {
                    console.log('Cought ERROR');
                    console.log(er);
                    return throwError(er);
                })
            );
    }

    deletePosts() {
        return this.http.delete(
            'https://ng-complet-guid.firebaseio.com/posts.json',
            {
                observe: 'events',
                responseType: 'text'
            }
        ).pipe(
            tap(event => {
                if (event.type === HttpEventType.Sent) {
                    console.log('request sent');
                }
                if (event.type === HttpEventType.Response) {
                    console.log(event.body);
                }
            })
        );
    }
}
