import AddQuestionsForm from "../components/AddQuestionsForm";
import CreateQuizForm from "../components/CreateQuizForm";
import Header from "../components/Header";
import { useState } from "react";
const CreateQuiz = () => {
  const [created, setCreated] = useState(false);
  const [quizData, setQuizData] = useState({});

  const handleCreated = (data) => {
    setQuizData(data);
    setCreated(true);
  };
  return (
    <div className="bg-neutral-content max-w-full h-screen font-mono">
      <Header title="Create Quiz" />
      <div className="mx-auto w-1/2 justify-center">
        {!created ? (
          <CreateQuizForm onCreated={handleCreated} />
        ) : (
          <AddQuestionsForm quizData={quizData} />
        )}
      </div>
    </div>
  );
};

export default CreateQuiz;
