object Sieve {
    fun primesUpTo(limit: Int) : List<Int> =
        (2..limit).filter { isPrime(it) }

    private fun isPrime(number: Int) : Boolean =
        !(2 until number).any() { number.rem(it) == 0 }
}