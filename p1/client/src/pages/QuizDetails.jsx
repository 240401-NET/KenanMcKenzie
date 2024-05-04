import { useLocation } from "react-router-dom";
import Header from "../components/Header";
const QuizDetails = () => {
  const { state } = useLocation();
  const quiz = state?.quiz;
  console.log("quiz", typeof quiz);
  return (
    <div>
      <Header title={quiz.title} />
      <h2>Quiz Details</h2>
      <div>Description: {quiz.description}</div>
      <div>Created By: {quiz.createdByNavigation?.name}</div>
      <h3>Questions:</h3>
      {quiz.questions?.map((question) => (
        <div key={question.questionId}>
          <h4>{question.questionText}</h4>
          <p>Example: {question.example}</p>
          <ul>
            {question.questionOptions.map((option) => (
              <li key={option.optionId}>
                {option.optionText} {option.isAnswer ? "(Correct)" : ""}
              </li>
            ))}
          </ul>
        </div>
      ))}
      <h3>Tags:</h3>
      <ul>
        {quiz.tags.map((tag) => (
          <li key={tag.tagId}>{tag.tagName}</li>
        ))}
      </ul>
    </div>
  );
};

export default QuizDetails;
