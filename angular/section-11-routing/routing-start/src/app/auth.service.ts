export class AuthService {
    loggiedIn = true;

    isAuthenticated() {
        const promise = new Promise(
            (resolve, reject) => {
                setTimeout(() => {
                    resolve(this.loggiedIn);
                },
                    100
                );
            }
        );
        return promise;
    }

    login() {
        this.loggiedIn = true;
    }

    logout() {
        this.loggiedIn = false;
    }
}