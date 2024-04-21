import axios from "axios";
import PropTypes from "prop-types";
import { useEffect, useState } from "react";

const QuizzesTable = ({ userId }) => {
  const [quizzes, setQuizzes] = useState([]);
  console.log("brucelee usrId", userId);
  useEffect(() => {
    const fetchQuizzes = async (userId) => {
      console.log("userId", userId);
      try {
        const response = await axios.get(`/api/quiz/${userId}`, {
          withCredentials: true,
          headers: {
            "Content-Type": "application/json",
          },
        });
        const data = await response.data;
        console.log("data", data);
        setQuizzes(data);
        console.log(quizzes);
        localStorage.setItem("quizzes", JSON.stringify(data.result));
        console.log("data:", data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchQuizzes(userId);
  }, [userId]);
  return (
    <div className="grid grid-cols-3 gap-8">
      {quizzes.map((quiz) => (
        <div key={quiz.id} className="w-3/4 mx-auto hover:scale-110">
          <div className="mockup-code">
            <pre data-prefix="$">
              <code>{quiz.title}</code>
            </pre>
            <pre data-prefix=">" className="text-warning">
              <code>{quiz.description}</code>
            </pre>
            <pre data-prefix=">" className="text-red-500">
              <code className="text-red-500">
                Tags:{" "}
                {quiz.tags.length > 0
                  ? quiz.tags.map((tag, index) => (
                      <span key={index}>
                        {tag.tagName}
                        {index < quiz.tags.length - 1 ? ", " : ""}
                      </span>
                    ))
                  : ""}
              </code>
            </pre>
            <pre data-prefix=">" className="text-success">
              <code>Questions: {quiz.questions.length}</code>
            </pre>
          </div>
        </div>
      ))}
    </div>
  );
};

export default QuizzesTable;

QuizzesTable.propTypes = {
  userInfo: PropTypes.object,
  userId: PropTypes.string,
};
