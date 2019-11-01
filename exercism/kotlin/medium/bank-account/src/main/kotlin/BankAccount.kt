class BankAccount() {
    var balance: Int
       private set
       get() { validate(); return field }
    var isClosed = false

    init { balance = 0 }

    fun adjustBalance(amount: Int) {
        validate()
        synchronized(this) {
            balance += amount
        }
    }

    fun close() { isClosed = true }

    private fun validate() = if (isClosed) throw IllegalStateException() else Unit
}