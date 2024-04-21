import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Header from "../components/Header";
const QuizDetails = () => {
  const { userId, id } = useParams();
  const [quiz, setQuiz] = useState(null);

  useEffect(() => {
    const fetchQuiz = async (id) => {
      try {
        const response = await axios.get(`/api/quiz/${userId}/${id}`, {
          withCredentials: true,
          headers: {
            "Content-Type": "application/json",
          },
        });
        const data = await response.data;
        setQuiz(data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchQuiz(id);
  }, [id]);
  return (
    <div>
      <Header title={quiz?.title} />
    </div>
  );
};

export default QuizDetails;
