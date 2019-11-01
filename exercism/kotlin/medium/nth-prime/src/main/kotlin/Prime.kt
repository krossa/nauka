object Prime {
    fun nth(nthPrime: Int) : Int {
        require(nthPrime > 0) { "There is no zeroth prime." }
        var primes = mutableListOf<Int>()
        var number = 2
        while (primes.size < nthPrime) {
            if(isPrime(number)) primes.add(number)
            number++
        }
        return primes.last()
    }

    private fun isPrime(number: Int) : Boolean =
        !(2 until number).any() { number.rem(it) == 0 }
}