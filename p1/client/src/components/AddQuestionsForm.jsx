import PropTypes from 'prop-types'
const AddQuestionsForm = ({ quizTitle, tags }) => {
  return (
    <div>
      <h2>{quizTitle}<span>{tags}</span></h2>
      <label className="form-control w-full w-64">
        <div className="label">
          <span className="label-text">Question Text</span>
        </div>
        <input type="text" placeholder="Type here" className="input input-bordered w-full max-w-xs" />
      </label>
      <label className="form-control w-full w-64">
        <div className="label">
          <span className="label-text">Option 1</span>
        </div>
        <input type="text" placeholder="Type here" className="input input-bordered w-full max-w-xs" />
      </label>
      <label className="form-control w-full w-64">
        <div className="label">
          <span className="label-text">Option 2</span>
        </div>
        <input type="text" placeholder="Type here" className="input input-bordered w-full max-w-xs" />
      </label>
      <label className="form-control w-full w-64">
        <div className="label">
          <span className="label-text">Option 3</span>
        </div>
        <input type="text" placeholder="Type here" className="input input-bordered w-full max-w-xs" />
      </label>
      <label className="form-control w-full w-64">
        <div className="label">
          <span className="label-text">Option 4</span>
        </div>
        <input type="text" placeholder="Type here" className="input input-bordered w-full max-w-xs" />
      </label>
    </div>
  )
}

export default AddQuestionsForm

AddQuestionsForm.propTypes = {
  quizTitle: PropTypes.string.isRequired,
  tags: PropTypes.array
}