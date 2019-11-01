class PhoneNumber(private val phone: String) {
    val number : String? 
    get() {
        val digits = phone.filter { it.isDigit() }.dropWhile { it.isZeroOrOne() }
        return if (digits.length == 10 && !digits[3].isZeroOrOne() ) digits else null
    } 

    private fun Char.isZeroOrOne(): Boolean = ('0'..'1').contains(this)
}