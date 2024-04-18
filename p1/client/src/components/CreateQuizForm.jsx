import { useState } from "react";
import { IoIosAddCircleOutline } from "react-icons/io";
import PropTypes from "prop-types";

const CreateQuizForm = ({ onCreated }) => {
  const [quizTitle, setQuizTitle] = useState("");
  const [description, setDescription] = useState("");
  const [tag, setTag] = useState("");
  const [tagArray, setTagArray] = useState([]);
  const [error, setError] = useState("");

  const handleAddTag = () => {
    if (tagArray.length < 3) {
      setTagArray([...tagArray, tag]);
      console.log("tag: " + tag);
      console.log("tagArray: " + tagArray.length);
      setTag("");
    } else {
      setError("You can only add 3 tags");
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("quizTitle: " + quizTitle);
    console.log("description: " + description);
    console.log("tagArray: " + tagArray);
    onCreated({ quizTitle, description, tagArray });
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="flex flex-col border-red-200 items-center">
          <label className="w-full max-w-xs">
            <div className="label">
              <span className="label-text">Title</span>
            </div>
            <input
              type="text"
              placeholder="Type here"
              required
              value={quizTitle}
              onChange={(e) => setQuizTitle(e.target.value)}
              className="input input-bordered w-full max-w-xs"
            />
          </label>
          <label className="w-full max-w-xs">
            <div className="label">
              <span className="label-text">Description</span>
            </div>
            <input
              type="text"
              placeholder="Type here"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              className="input input-bordered w-full max-w-xs"
            />
          </label>
          {/*Question*/}
          <p>{quizTitle}</p>

          {/*Don't display until the end*/}
          <div className="flex w-full justify-center items-center">
            <label className="form-control w-full max-w-xs">
              <div className="label">
                <span className="label-text">Add tags</span>
                {error && (
                  <span className="text-red-500 label-text">{error}</span>
                )}
              </div>
              <div className="flex items-center">
                <input
                  type="text"
                  placeholder="Type here"
                  value={tag}
                  onChange={(e) => setTag(e.target.value)}
                  className="input input-bordered  mr-4"
                />
                <button type="button" onClick={handleAddTag}>
                  <IoIosAddCircleOutline className="text-3xl" />
                </button>
              </div>
            </label>
          </div>

          <div className="flex justify-start pt-2 gap-x-2 ">
            {tagArray.map((tag, index) => (
              <p
                key={index}
                className="bg-amber-400 text-neutral p-1.5 rounded-lg"
              >
                {tag}
              </p>
            ))}
          </div>
        </div>
        <div className="flex justify-center pt-6 ">
          <button
            type="submit"
            className="btn bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600"
          >
            Add Questions
          </button>
        </div>
      </form>
    </div>
  );
};

export default CreateQuizForm;

CreateQuizForm.propTypes = {
  onCreated: PropTypes.func.isRequired,
};
