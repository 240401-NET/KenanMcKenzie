import axios from "axios";

export const handleSubmitQuiz = async (quizData, id, navigate) => {
  const formData = {
    Title: quizData.quizTitle,
    Tags: quizData.tagArray,
    CreatedBy: id,
    Description: quizData.description,
    Questions: quizData.questions,
  };

  try {
    const response = await axios.post("api/quiz", JSON.stringify(formData), {
      withCredentials: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
    });
    if (response.status === 200) {
      alert("Quiz created successfully");
      navigate("/user");
    } else {
      console.error(response.data.message);
      return (
        <div className="toast toast-top toast-center">
          <div className="error error-info">
            <span>Try again.</span>
          </div>
        </div>
      );
    }
  } catch (error) {
    console.error(error);
  }
};

export const handleAppendQuestions = (questionArray, quizData) => {
  quizData.questions = questionArray;
  console.log("quizData: ", quizData);
};
