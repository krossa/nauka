export class CounterService {
    activations = 0;
    inactivations = 0;

    activation() {
        this.activations++;
        this.log();
    }

    inactivation() {
        this.inactivations++;
        this.log();
    }

    private log() {
        console.log('ACTIVATIONS: ' + this.activations + ' INACTIVATIONS: ' + this.inactivations);
    }
}
