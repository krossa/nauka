import kotlin.math.*

data class ComplexNumber(val real: Double = 0.0, val imag: Double = 0.0) {

    val abs = Math.sqrt(real.pow(2) + imag.pow(2))

    fun conjugate() = ComplexNumber(real, -imag)

    operator fun div(other: ComplexNumber) = ComplexNumber(
        (real * other.real + imag * other.imag) / (other.real.pow(2) + other.imag.pow(2)),
        (imag * other.real - real * other.imag)/(other.real.pow(2) + other.imag.pow(2))
    )
    operator fun minus(other: ComplexNumber) = ComplexNumber(real - other.real, imag - other.imag)
    operator fun plus(other: ComplexNumber) : ComplexNumber = ComplexNumber(real + other.real, imag + other.imag)
    operator fun times(other: ComplexNumber) : ComplexNumber = 
        ComplexNumber(real * other.real - imag * other.imag, imag * other.real + real * other.imag)
}

fun exponential(z: ComplexNumber): ComplexNumber =
        ComplexNumber(real = Math.exp(z.real)) * ComplexNumber(real = Math.cos(z.imag), imag = Math.sin(z.imag))