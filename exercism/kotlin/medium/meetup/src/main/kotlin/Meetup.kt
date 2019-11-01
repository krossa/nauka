import java.time.DayOfWeek
import java.time.LocalDate
import java.time.YearMonth

class Meetup(private val month: Int, private val year: Int) {
    fun day(day_of_week: DayOfWeek, schedule: MeetupSchedule) : LocalDate {
        return when (schedule) {
            MeetupSchedule.LAST -> getDay(day_of_week, YearMonth.of(year, month).lengthOfMonth() - 6)
            MeetupSchedule.TEENTH -> getDay(day_of_week, 13)
            else -> getNthDay(day_of_week, schedule.ordinal + 1)
        }
    }

    private fun getNthDay(day_of_week: DayOfWeek, limit: Int) : LocalDate {
        var date = LocalDate.of(year, month, 1)
        var count = if (date.getDayOfWeek() == day_of_week) 1 else 0
        while (date.getDayOfWeek() != day_of_week || count < limit) {
            date = date.plusDays(1) 
            if (date.getDayOfWeek() == day_of_week) count++
        }
        return date
    }

    private fun getDay(day_of_week: DayOfWeek, limit: Int) : LocalDate {
        var date = LocalDate.of(year, month, 1)
        while (date.getDayOfWeek() != day_of_week || date.getDayOfMonth() < limit) 
            date = date.plusDays(1)
        return date
    }
}