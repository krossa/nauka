class Reactor<T>() {
    // Your compute cell's addCallback method must return an object
    // that implements the Subscription interface.
    interface Subscription {
        fun cancel()
    }

    var value: T
        get() = filed
        set(v) {
            field = v
        }

    fun InputCell(input: T) {
        // value = input
    }
}