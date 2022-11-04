import React, { Component } from "react";
import { connect } from "react-redux";

class TransactionsTable extends Component {
  state = {
    errors: [],
    successMessage: null,
    loading: true,
    newTransaction: {
      description: "",
      timestamp: "",
    },
  };

  componentDidMount = async () => {
    await this.props.fetchTransactions();
    this.setState({ loading: false });
  };

  renderMessages = () => {
    /*
           Look into the local state to see if we have any errors
           that are derived from the backend validation, and display them
        */
    const errors = [];
    if (this.state.errors) {
      for (let err in this.state.errors) {
        errors.push(<li>{this.state.errors[err]}</li>);
      }
    }

    if (errors.length > 0) {
      return (
        <div className={"alert alert-danger"}>
          <p>The following errors prevented a successful save:</p>
          <ul>{errors}</ul>
        </div>
      );
    }

    if (this.state.successMessage !== null) {
      return (
        <p className={"alert alert-success"}>{this.state.successMessage}</p>
      );
    }

    return null;
  };

  renderTable = () => {
    return (
      <div className="table-responsive">
        <table
          className="table table-striped table-bordered table-hover"
          aria-labelledby="tabelLabel"
        >
          <thead>
            <tr>
              <th>ID</th>
              <th>Description</th>
              <th>Timestamp</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.props.transactions?.length === 0 && (
              <tr>
                <td colSpan="6" style={{ textAlign: "center" }}>
                  There are no transaction.
                </td>
              </tr>
            )}
            {this.props.transactions?.map((transaction) => (
              <tr key={`transaction-row-${transaction.id}`}>
                <td>{transaction?.id}</td>
                <td>{transaction?.description}</td>
                <td>{transaction?.timestamp}</td>
                <td></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  };

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderTable()
    );
    return <>{contents}</>;
  }
}
const mapStateToProps = (state) => ({ transactions: state.transactions });
export default connect(mapStateToProps)(TransactionsTable);
