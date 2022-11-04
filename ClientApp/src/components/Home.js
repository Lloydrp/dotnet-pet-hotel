import React, { Component } from "react";
import PetsTable from "./PetsTable";
import PetOwnersTable from "./PetOwnersTable";
import TransactionsTable from "./TransactionsTable";
import axios from "axios";
import { connect } from "react-redux";

class Home extends Component {
  static displayName = Home.name;

  fetchPetOwners = async () => {
    const response = await axios.get("api/petOwners");
    this.props.dispatch({ type: "SET_PETOWNERS", payload: response.data });
  };

  fetchTransactions = async () => {
    const response = await axios.get("api/transactions");
    // console.log(response.data);
    this.props.dispatch({ type: "SET_TRANSACTIONS", payload: response.data });
  };

  render() {
    return (
      <>
        <h1>Welcome To The Pet Hotel!</h1>
        <p>At our Pet Hotel, we take care of your pet while you are away. </p>
        <PetsTable fetchPetOwners={this.fetchPetOwners} />
        <br />
        <PetOwnersTable fetchPetOwners={this.fetchPetOwners} />
        <br />
        <TransactionsTable fetchTransactions={this.fetchTransactions} />
      </>
    );
  }
}

export default connect()(Home);
