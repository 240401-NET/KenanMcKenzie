import CreateQuizForm from "../components/CreateQuizForm"
import Header from "../components/Header"

const CreateQuiz = () => {
  return (
    <div className="flex flex-col items-center text-center border ">
      <Header title="Create Quiz" />
      <div className="">
      <CreateQuizForm />
      
      </div>
    </div>
  )
}

export default CreateQuiz