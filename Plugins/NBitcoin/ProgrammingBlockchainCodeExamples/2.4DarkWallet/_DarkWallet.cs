﻿using NBitcoin;
using NBitcoin.Stealth;

namespace ProgrammingBlockchainCodeExamples
{
	public class _DarkWallet : UnityEngine.MonoBehaviour
	{
		void Start()
		{
            BookExamples();
			EasyImplementation();
		}

		static void EasyImplementation()
		{
			BitcoinStealthAddress address = ReceiverCreateStealthAddress();
			Transaction transaction = SenderCreateTransaction(address);
		}

		static BitcoinStealthAddress ReceiverCreateStealthAddress()
		{
			var scanKey = new Key();
			var spendKey = new Key();
			BitcoinStealthAddress stealthAddress
				= new BitcoinStealthAddress
					(
					scanKey: scanKey.PubKey,
					pubKeys: new[] { spendKey.PubKey },
					signatureCount: 1,
					bitfield: null,
					network: Network.Main);
			return stealthAddress;
		}

		static Transaction SenderCreateTransaction(BitcoinStealthAddress address)
		{
			Transaction transaction = new Transaction();
			address.SendTo(transaction, new Money(3, MoneyUnit.BTC));
			return transaction;
		}

		static void BookExamples()
		{
			var scanKey = new Key();
			var spendKey = new Key();
			BitcoinStealthAddress stealthAddress
				= new BitcoinStealthAddress
					(
					scanKey: scanKey.PubKey,
					pubKeys: new[] { spendKey.PubKey },
					signatureCount: 1,
					bitfield: null,
					network: Network.Main);

			var ephemKey = new Key();
			Transaction transaction = new Transaction();
			stealthAddress.SendTo(transaction, Money.Coins(1.0m), ephemKey);
			UnityEngine.Debug.Log(transaction);
		}
	}
}