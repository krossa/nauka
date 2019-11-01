import java.util.*

object BracketPush {
    val brackets = mapOf<Char,Char>('{' to '}', '[' to ']', '(' to ')')

    fun isValid(input: String) : Boolean {
        var expected_closing_brackets = Stack<Char>()
        for (letter in input) {
            if (brackets.containsKey(letter)) expected_closing_brackets.push(brackets[letter]!!)
             else if(brackets.containsValue(letter)) {
                if (expected_closing_brackets.tryPop() != letter) return false
            }
        }
        return if (expected_closing_brackets.isEmpty()) true else false
    }
}

private fun <E> Stack<E>.tryPop(): E? = when {
    this.empty() -> null
    else -> this.pop()
}