import QuizzesTable from "../components/QuizzesTable"

const PopularQuizzes = () => {
  //useEffect -> import and call getPopular from /api ->set state
  return (
    <div>
      <p>popular quizzes</p>
      <QuizzesTable />
    </div>
  )
}

export default PopularQuizzes