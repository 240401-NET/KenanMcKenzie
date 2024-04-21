import PropTypes from "prop-types";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { handleSubmitQuiz, handleAppendQuestions } from "../api/quizService";
const AddQuestionsForm = ({ quizData }) => {
  const [questionText, setQuestionText] = useState("");
  const [options, setOptions] = useState([
    { OptionText: "", IsAnswer: false },
    { OptionText: "", IsAnswer: false },
    { OptionText: "", IsAnswer: false },
    { OptionText: "", IsAnswer: false },
  ]);
  const [example, setExample] = useState("");
  const [questionArray, setQuestionArray] = useState([]);
  const [id, setId] = useState();

  useEffect(() => {
    const userInfo = JSON.parse(localStorage.getItem("userInfo"));
    console.log("userInfo: ", userInfo);
    setId(userInfo.id);
  }, []);
  const navigate = useNavigate();
  /*             submits                */
  const handleAddQuestion = (e) => {
    e.preventDefault();
    const newQuestion = {
      questionText,
      options,
      example,
    };
    const answer = (element) => element.IsAnswer === true;
    const answerPresent = options.findIndex(answer);
    if (answerPresent == -1) {
      alert("Please select an answer");
      return;
    }
    setQuestionArray([...questionArray, newQuestion]);
    handleReset();

    console.log("questionArray: ", questionArray);
  };

  const handleReset = () => {
    setQuestionText("");
    setOptions([
      { OptionText: "", IsAnswer: false },
      { OptionText: "", IsAnswer: false },
      { OptionText: "", IsAnswer: false },
      { OptionText: "", IsAnswer: false },
    ]);
    setExample("");
  };

  const onSubmitQuiz = (e) => {
    e.preventDefault();
    handleAppendQuestions(questionArray, quizData);
    handleSubmitQuiz(quizData, id, navigate);
  };

  // const handleSubmitQuiz = async (e) => {
  //   e.preventDefault();
  //   handleAppendQuestions();
  //   console.log("username: ", id);
  //   const formData = {
  //     Title: quizData.quizTitle,
  //     Tags: quizData.tagArray,
  //     CreatedBy: id,
  //     Description: quizData.description,
  //     Questions: quizData.questions,
  //   };
  //   console.log(typeof formData.CreatedBy);
  //   const response = await axios.post("api/quiz", JSON.stringify(formData), {
  //     withCredentials: true,
  //     headers: {
  //       "Content-Type": "application/json",
  //       Accept: "application/json",
  //     },
  //   });
  //   const data = await response.data;
  //   console.log(data);
  //   if (response.ok) {
  //     console.log(data);
  //     alert("Quiz created successfully");
  //     navigate("/user");
  //   } else {
  //     console.error(data.message);

  //   }
  // };

  return (
    <div>
      <div className="flex  w-full justify-between gap-4 px-4  items-center">
        <p className="text-2xl font-bold ">{quizData.quizTitle}</p>
        <div className="flex gap-2">
          {quizData.tagArray.map((tag, index) => (
            <p
              key={index}
              className="bg-amber-400 text-neutral p-1.5 rounded-lg w-20 text-center"
            >
              {tag}
            </p>
          ))}
        </div>
      </div>
      <div className="flex flex-col">
        <h1 className="text-center text-4xl pt-4">
          Question {questionArray.length + 1}
        </h1>

        <form onSubmit={handleAddQuestion}>
          <label className="form-control w-full px-6">
            <div className="label">
              <span className="label-text">Question Text</span>
            </div>
            <textarea
              placeholder="Type here"
              className="input input-bordered h-24"
              value={questionText}
              onChange={(e) => setQuestionText(e.target.value)}
            />
          </label>

          {options.map((option, index) => (
            <div key={index} className="flex">
              <label className="form-control px-6 w-full ">
                <div className="label">
                  <span className="label-text">Option {option.OptionId}</span>
                </div>
                <div className="flex items-center gap-2">
                  <input
                    type="text"
                    placeholder="Type here"
                    className="input input-bordered w-full "
                    value={option.OptionText}
                    onChange={(e) => {
                      const newOptions = [...options];
                      newOptions[index].OptionText = e.target.value;
                      setOptions(newOptions);
                    }}
                  />
                  <input
                    type="checkbox"
                    checked={option.IsAnswer}
                    onChange={(e) => {
                      const newOptions = options.map((option, optionIndex) =>
                        optionIndex === index
                          ? { ...option, IsAnswer: e.target.checked }
                          : { ...option, IsAnswer: false }
                      );
                      setOptions(newOptions);
                    }}
                    className="checkbox checkbox-warning"
                  />
                </div>
              </label>
              <label></label>
            </div>
          ))}
          <div className="flex justify-center pt-6 gap-4">
            <button
              type="button"
              className="btn bg-amber-400 border-neutral"
              onClick={(e) => {
                e.preventDefault();
                document.getElementById("my_modal_4").showModal();
              }}
            >
              Add Example
            </button>
            <dialog id="my_modal_4" className="modal">
              <div className="modal-box w-11/12 max-w-5xl">
                <label className="text-center">
                  <span className="font-semibold text-xl">Example</span>
                </label>
                <textarea
                  placeholder="Example here"
                  className="input input-bordered h-48 w-full"
                  value={example}
                  onChange={(e) => setExample(e.target.value)}
                />

                <div className="modal-action">
                  <form method="dialog">
                    <button className="bg-amber-400 px-2 py-1 rounded-lg text-xl w-16">
                      OK
                    </button>
                  </form>
                </div>
              </div>
            </dialog>
            <button className="btn bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600">
              Add Question
            </button>
          </div>
          <div className="flex justify-center w-full pt-6">
            <button
              type="button"
              onClick={onSubmitQuiz}
              className="bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600 rounded-lg py-1.5"
            >
              Done
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default AddQuestionsForm;

AddQuestionsForm.propTypes = {
  quizData: PropTypes.object,
};
